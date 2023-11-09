
var dataTable;
$(document).ready(function () {

    loadDataTable();
});


function loadDataTable() {
    dataTable = $('#ProductTable').DataTable({
        ajax: '/admin/product/getall',
        columns: [
            { data: 'title' },
            { data: 'isbn' },
            { data: 'price' },
            { data: 'author' },
            { data: 'category.name' },
            {
                data: "imgURL",
                render: function (data) {
                    return `<img src="${data}" width="40px">`;
                }
            },
            {
                data: 'id',
                render: function (id) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/admin/product/upsert?id=${id}" class="btn btn-sm btn-primary"><i class="bi bi-pencil-square"></i>Edit</a>
                            <a onclick=Delete("/admin/product/DeleteProduct?id=${id}") class="btn btn-sm btn-danger"><i class="bi bi-trash3"></i>Delete</a>
                        </div>
                    `
                }

            }
        ]

    })
}


function Delete(url) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    dataTable.ajax.reload()
                    toastr.success(data.message);
                }
            })
        }
    });
}