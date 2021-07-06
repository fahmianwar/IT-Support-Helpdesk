﻿$(document).ready(function () {
    var i = 1;
    console.log("Coba");
    $('#tableUsers').DataTable({
        ajax: {
            url: 'https://localhost:44381/api/Users/GetProfile',
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
                "data": "email"
            },
            {
                "render": function (data, type, row) {
                    var date = new Date(row['birthDate']);
                    return date.getDate() + "-" + date.getMonth() + "-" + date.getFullYear();
                }
            },
            {
                "render": function (data, type, row) {
                    if (row['phone'].charAt(0) == 0) {
                        return "+62" + row['phone'].substring(1);
                    } else {
                        return row['phone'];
                    }
                }
            },
            {
                "data": "address"
            },
            {
                "data": "department"
            },
            {
                "data": "company"
            },
            {
                "data": "roleName"
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-info" onclick="getUser('${row.id}')" data-toggle="modal" data-target="#editModal">Edit</button> | <button type="button" class="btn btn-danger" onclick="deleteUser('${row['id']}')">Delete</button>`;
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

function insertUser() {
    debugger
    var obj = new Object();
    obj.Name = $("#inputCreateName").val();
    obj.Email = $("#inputCreateEmail").val();
    obj.Password = $("#inputCreatePassword").val();
    obj.BirthDate = $("#inputCreateBirthDate").val();
    obj.Phone = $("#inputCreatePhone").val();
    obj.Address = $("#inputCreateAddress").val();
    obj.Department = $("#inputCreateDepartment").val();
    obj.Company = $("#inputCreateCompany").val();
    obj.RoleId = parseInt($("#inputCreateRole").val());
    obj.Detail = "";
    console.log(obj);
    console.log(JSON.stringify(obj));
    if (obj.Name == "" || obj.Email == "" || obj.Password == "" || obj.BirthDate == "" || obj.Phone == "" || obj.Address == "" || obj.Department == "" || obj.Company == "" || obj.RoleId < 0) {
        Swal.fire({
            title: 'Error!',
            text: 'Failed create user',
            icon: 'error',
            confirmButtonText: 'OK'
        });
    } else {
        $.ajax({
            url: 'https://localhost:44381/api/Users/',
            type: "POST",
            dataType: "json",
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
            }).then(function () {
                window.location.href = "/panel/users";
            });
            console.log(result);
            $('#tableUsers').DataTable().ajax.reload();
        }).fail((error) => {
            alert(error);
            Swal.fire({
                title: 'Error!',
                text: 'Gagal menambahkan data',
                icon: 'error',
                confirmButtonText: 'Ok'
            });
            console.log(error);
        });
    }
}

function openCreateUser() {
    $.ajax({
        url: 'https://localhost:44381/api/Roles/'
    }).done((result) => {
        text = "";
        $.each(result, function (key, val) {
            text += `<option value="${val.id}">${val.name}</option>`;
        });
        $("#inputCreateRole").html(text);
    }).fail((error) => {
        console.log(error);
    });
}



function editUser() {
    debugger
    var obj = new Object();
    obj.Id = $("#Id").val();
    obj.Name = $("#Name").val();
    obj.Email = $("#Email").val();
    if ($("#Password").val() != "") {
        obj.Password = $("#Password").val();
    }
    obj.BirthDate = $("#BirthDate").val();
    obj.Phone = $("#Phone").val();
    obj.Address = $("#Address").val();
    obj.Department = $("#Department").val();
    obj.Company = $("#Company").val();
    obj.RoleId = parseInt($("#Role").val());
    obj.Detail = "";
    console.log(obj);
    if (obj.Name == "" || obj.Email == "" || obj.BirthDate == "" || obj.Phone == "" || obj.Address == "" || obj.Department == "" || obj.Company == "") {
        Swal.fire({
            title: 'Error!',
            text: 'Failed Update Profile',
            icon: 'error',
            confirmButtonText: 'OK'
        });
    } else {
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
                    url: 'https://localhost:44381/api/Users',
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
            $('#tableUsers').DataTable().ajax.reload();
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
}

function getUser(id) {


    $.ajax({
        url: 'https://localhost:44381/api/Users/' + id,
        type: "GET",
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
    }).done((result) => {
        console.log(result);
        $("#Id").val(result.id);
        $("#Name").val(result.name);
        $("#Email").val(result.email);
        $("#BirthDate").val(result.birthDate);
        $("#Phone").val(result.phone);
        $("#Address").val(result.address);
        $("#Department").val(result.department);
        $("#Company").val(result.company);
        $("#Role").val(result.roleId);
        $.ajax({
            url: 'https://localhost:44381/api/Roles/'
        }).done((resultComboBox) => {
            text = "";
            $.each(resultComboBox, function (key, val) {
                if (val.id == result.roleId) {
                    text += `<option value="${val.id}" selected>${val.name}</option>`;
                } else {
                    text += `<option value="${val.id}">${val.name}</option>`;
                }
            });
            $("#Role").html(text);
        }).fail((error) => {
            console.log(error);
        });
    }).fail((error) => {
        alert(error);
        Swal.fire({
            title: 'Error!',
            text: 'Gagal menampilkan data',
            icon: 'error',
            confirmButtonText: 'Ok'
        });
        console.log(error);
    });
}


function deleteUser(id) {
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
                url: 'https://localhost:44381/api/Users/' + id,
                type: "DELETE",
            }).done((result) => {
                alert(result);
                Swal.fire(
                    'Deleted!',
                    'Your file has been deleted.',
                    'success'
                )
            });
            $('#tableUsers').DataTable().ajax.reload();
        }
    });
}
