var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/User/GetAll"
        },
        "columns": [
            { "data": "fullName" },
            { "data": "userName" },
            { "data": "email" },
            {
                "data": "emailConfirmed",
                "render": function (data) {
                    if (data) {
                        return `
                                <div class="text-center">
                                    <input type="checkbox" checked disabled />
                                </div>                                
                                `
                    }
                    else {
                        return `
                                <div class="text-center">
                                    <input type="checkbox" disabled />
                                </div> 
                                `
                    }
                }
            },
            { "data": "phoneNumber" },
            {
                "data": "phoneNumberConfirmed",
                "render": function (data) {
                    if (data) {
                        return `
                                <div class="text-center">
                                    <input type="checkbox" checked disabled />
                                </div>                                
                                `
                    }
                    else {
                        return `
                                <div class="text-center">
                                    <input type="checkbox" disabled />
                                </div> 
                                `
                    }
                }
            },
            { "data": "roles[</br>]" },
            {
                "data": { id: "id", lockoutEnd: "lockoutEnd", lockoutEnabled: "lockoutEnabled" },
                "render": function (data) {
                    if (data.lockoutEnabled) {
                        var today = new Date().getTime();
                        var lockout = new Date(data.lockoutEnd).getTime();
                        if (lockout > today) {
                            //user is currently locked
                            return `
                            <div class="text-center">                                
                                <a title="Unlock account" onclick=LockUnlock('${data.id}') class="btn btn-danger btn-sm text-white" style="cursor: pointer;">
                                    <i class="fas fa-lock-open"></i>
                                </a>
                            </div>
                            `;
                        }
                        else {
                            return `
                            <div class="text-center">
                                <a title="Edit account" href="/Identity/Account/Manage/Index?id=${data.id}" class="btn btn-sm btn-warning text-white" style="cursor: pointer">
                                    <i class="fas fa-edit"></i>
                                </a>
                                <button title="Lock account" onclick=LockUnlock('${data.id}') class="btn btn-sm btn-success text-white" style="cursor: pointer">
                                    <i class="fas fa-lock"></i>
                                </button>
                            </div>
                            `;
                        }
                    }
                    else {
                        return `
                            <div class="text-center">
                                <a title="Edit account" href="/Identity/Account/Manage/Index?id=${data.id}" class="btn btn-sm btn-warning text-white" style="cursor: pointer;">
                                    <i class="fas fa-edit"></i>
                                </a>
                            </div>
                            `;
                    }
                }
            }
        ],
    });
}

function LockUnlock(id) {
    $.ajax({
        type: "POST",
        url: '/Admin/User/LockUnlock',
        data: JSON.stringify(id),
        contentType: "application/json",
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }
            else {
                toastr.error(data.message);
            }
        }
    });
}