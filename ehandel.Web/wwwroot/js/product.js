﻿var dataTable;

$(document).ready(function () {
    loadDataTable();
})



function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url":"/Product/GetAll"
        },
        "columns": [
            {
                "data": "imageUrl",
                "render": function (data) {
                    return `
                        <img src="${data}" alt="Product image" width="80" height="80">
                        `
                },
                "width": "10px"
            },
            { "data": "sku",          "width": "30%" },
            { "data": "name",           "width": "10%" },
            { "data": "description",           "width": "20%" },
            { "data": "productRating.rating", "width": "5%" },
            { "data": "price",          "width": "5%" },
            { "data": "category.name",  "width": "5%" },
            { "data": "createdDateTime", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-75 btn-group" role="group">
                            <a href="/Product/Upsert?id=${data}" 
                            class="btn btn-primary mx-2"><i class="bi bi-pencil-square"></i>&nbsp; Edit</a>
                            <a onClick=Delete('/Product/Delete/${data}')
                            class="btn btn-danger mx-2"><i class="bi bi-pencil-square"></i>&nbsp; Delete</a>
                        </div>
                        `
                },
                "width": "5%"
            },
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
                        $('#tblData').DataTable().ajax.reload()
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}