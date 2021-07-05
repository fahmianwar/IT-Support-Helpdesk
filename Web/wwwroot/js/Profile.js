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



function editProfile() {
    debugger
    var obj = new Object();
    obj.Id = $("#Id").val();
    obj.Name = $("#Name").val();
    obj.Email = $("#Email").val();
    obj.Password = $("#Password").val();
    obj.BirthDate = $("#BirthDate").val();
    obj.Phone = $("#Phone").val();
    obj.Address = $("#Address").val();
    obj.Department = $("#Department").val();
    obj.Company = $("#Company").val();
    obj.RoleId = parseInt($("#Role").val());
    obj.Detail = "";
    console.log(obj);
    if (obj.Name == "" || obj.Email == "" || obj.Password == "" || obj.BirthDate == "" || obj.Phone == "" || obj.Address == "" || obj.Department == "" || obj.Company == "") {
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
            $('#formProfile').ajax.reload();
        }).fail((error) => {
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

function getProfile(id) {
    console.log(id);
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
        $("#Password").val(result.password);
        $("#BirthDate").val(result.birthDate);
        $("#Phone").val(result.phone);
        $("#Address").val(result.address);
        $("#Department").val(result.department);
        $("#Company").val(result.company);
        $("#Role").val(result.roleId);
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
