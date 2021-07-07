﻿$(document).ready(function () {
    var i = 1;
    console.log("Coba");
    $('#tableStatusCodes').DataTable({
        ajax: {
            url: 'https://localhost:44357/Panel/GetStatusCodes',
            dataSrc: ''
        },
        columns: [

            {
                "data": null, "sortable": false,
                render: function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            {
                "data": "name"
            },
            {
                "data": "description"
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-outline-info" onclick="getStatusCode('${row.id}')" data-toggle="modal" data-target="#editModal"><i class="far fa-edit"></i></button> | <button type="button" class="btn btn-outline-danger" onclick="deleteStatusCode('${row['id']}')"><i class="fas fa-times"></i></button>`;
                }
            }
        ]
    });

});

(function () {
    'use strict';
    window.addEventListener('load', function () {
        // Fetch all the forms we want to apply custom Bootstrap validation styles to
        var forms = document.getElementsByClassName('needs-validation');
        // Loop over them and prevent submission
        var validation = Array.prototype.filter.call(forms, function (form) {
            form.addEventListener('submit', function (event) {
                if (form.checkValidity() === false) {
                    event.preventDefault();
                    event.stopPropagation();
                }
                form.classList.add('was-validated');
            }, false);
        });
    }, false);
})();

function insertStatusCode() {
    var obj = new Object();
    obj.Name = $("#inputCreateName").val();
    obj.Description = $("#inputCreateDescription").val();
    console.log(obj);
    console.log(JSON.stringify(obj));
    if (obj.Name == "" || obj.Description == "") {
        Swal.fire({
            title: 'Error!',
            text: 'Failed create Status Code',
            icon: 'error',
            confirmButtonText: 'OK'
        });
    } else {
        $.ajax({
            url: 'https://localhost:44381/api/StatusCodes',
            type: "POST",
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            data: JSON.stringify(obj)
        }).done((result) => {
            alert(result);
            Swal.fire({
                title: 'Success!',
                text: 'Berhasil menambahkan data',
                icon: 'success',
                confirmButtonText: 'Cool'
            });
            //$('#tableProfiles').DataTable().ajax.reload();
            console.log(result);
            $('#tableStatusCodes').DataTable().ajax.reload();
        }).fail((error) => {
            alert(error);
            Swal.fire({
                title: 'Error!',
                text: 'Gagal menambahkan data',
                icon: 'error',
                confirmButtonText: 'Cool'
            });
            console.log(error);
        });
    }
}

function editStatusCode() {
    debugger
    var obj = new Object();
    obj.id = $("#Id").val();
    obj.Name = $("#Name").val();
    obj.Description = $("#Description").val();
    console.log(obj);
    console.log(JSON.stringify(obj));
    Swal.fire({
        title: 'Do you want to save the changes?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: `Save`,
        denyButtonText: `Don't save`,
    }).then((result) => {
        /* Read more about isConfirmed, isDenied below */
        if (result.isConfirmed) {
            $.ajax({
                url: 'https://localhost:44381/api/StatusCodes',
                type: "PUT",
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                data: JSON.stringify(obj),
            }).done((result) => {
                Swal.fire('Saved!', '', 'success')
            })
        } else if (result.isDenied) {
            Swal.fire('Changes are not saved', '', 'info')
        }
        console.log(result);
        $('#tableStatusCodes').DataTable().ajax.reload();
    }).fail((error) => {
        alert(error);
        Swal.fire({
            title: 'Error!',
            text: 'Gagal update data',
            icon: 'error',
            confirmButtonText: 'Ok'
        });
        console.log(error);
    });
}

function getStatusCode(id) {
    console.log(id);
    $.ajax({
        url: 'https://localhost:44381/api/StatusCodes/' + id,
        dataSrc: ''
        //type: "GET",
        //headers: {
        //    'Accept': 'application/json',
        //    'Content-Type': 'application/json'
        //},
    }).done((result) => {
        console.log(result);
        $("#Id").val(result.id);
        $("#Name").val(result.name);
        $("#Description").val(result.description);
    }).fail((error) => {
        Swal.fire({
            title: 'Error!',
            text: 'Gagal menampilkan data',
            icon: 'error',
            confirmButtonText: 'Ok'
        });
        console.log(error);
    });
}


function deleteStatusCode(id) {
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
                url: 'https://localhost:44381/api/StatusCodes/' + id,
                type: "DELETE",
            }).done((result) => {
                alert(result);
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            });
            $('#tableStatusCodes').DataTable().ajax.reload();
        }
    });
}
