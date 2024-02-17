var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tbldata').DataTable({
        "ajax": {
            "url": "/Admin/Staff/GetAll"
        },
        "columns": [
            { "data": "name", "width": "25%" },
            { "data": "streetAddress", "width": "15%" },
            { "data": "city", "width": "10%" },
            { "data": "state", "width": "10%" },
         
            { "data": "phoneNumber", "width": "15%" },
            { "data": "emailAddress", "width": "15%" },
            {
                "data": "password",
                "render": function (data) {
                    // Display stars instead of the actual password
                    return '*'.repeat(data.length);
                },
                "width": "15%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return '<div class="w-75 btn-group" role="group">' +
                        '<a href="/Admin/Staff/Upsert?id=' + data + '" class="btn btn-primary mx-2">' +
                        '<i class="bi bi-pencil-square"></i> Edit</a>' +
                        '<a onclick="Delete(\'/Admin/Staff/Delete/' + data + '\')" class="btn btn-danger mx-2">' +
                        '<i class="bi bi-trash-fill"></i> Delete</a>' +
                        '</div>';
                },
                "width": "25%"
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
