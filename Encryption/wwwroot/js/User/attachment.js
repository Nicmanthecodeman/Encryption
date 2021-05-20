var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/User/Attachment/GetAll"
        },
        "columns": [
            {
                "data": "fileName",
            },
            {
                "data": "mimeType",
            },
            {
                "data": "uploaded",
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">                                
                                <a title="Edit" href="/Admin/Role/Upsert/${data}" class="text-warning" style="cursor: pointer;">
                                    <i class="fas fa-edit"></i>
                                </a>
                                <a target="_blank" title="Download" onclick="Download('${data}')" class="text-secondary" style="cursor: pointer;">
                                    <i class="fas fa-download"></i>
                                </a>
                            </div>
                            `;
                },
            }
        ],
        "columnDefs": [
            {
                orderable: false,
                targets: 3
            }
        ]
    });
}

function Download(id) {
    $('#attachmentId').val(id);
    $('#attachment-download-form').submit();
}