var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Role/GetAll"
        },
        "columns": [
            {
                "data": "name",
                "width": "60%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">                                
                                <a title="Edit" href="/Admin/Role/Upsert/${data}" class="text-warning" style="cursor: pointer;">
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a title="Delete" onclick="Delete('/Admin/Role/Delete/${data}')" class="text-danger" style="cursor: pointer;">
                                    <i class="fas fa-trash"></i>
                                </a>
                            </div>
                            `;
                },
                "width": "40%"
            }
        ],
        "columnDefs": [
            {
                orderable: false,
                targets: 1
            }
        ]
    });
}

function Delete(url) {
    swal.fire({
        "title": "Are you sure?",
        "text": "This cannot be reversed!",
        "icon": "warning",
        "showCancelButton": true,
        "reverseButtons": true,
        "confirmButtonText": "Delete",
        "confirmButtonColor": '#d33',        
    }).then((willDelete) => {
        if (willDelete.isConfirmed) {
            $.ajax({
                "method": "DELETE",
                "url": url,
                "dataType": "JSON",
                "success": function (data) {
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
    });
}