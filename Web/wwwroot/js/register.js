function register() {
    var obj = new Object();
    obj.Name = $("#inputName").val();
    obj.Email = $("#inputEmail").val();
    obj.Password = $("#inputPassword").val();
    obj.BirthDate = $("#inputBirthDate").val();
    obj.Phone = $("#inputPhone").val();
    obj.Address = $("#inputAddress").val();
    obj.Department = $("#inputDepartment").val();
    obj.Company = $("#inputCompany").val();
    //console.log(obj);
    //console.log(JSON.stringify(obj));
    if (obj.Name == "" || obj.Email == "" || obj.Password == "" || obj.BirthDate == "" || obj.Phone == "" || obj.Address == "" || obj.Department == "" || obj.Company == "") {
        Swal.fire({
            title: 'Error!',
            text: 'Failed create user',
            icon: 'error',
            confirmButtonText: 'OK'
        });
    } else {
        $.ajax({
            url: 'https://localhost:44381/api/Users/Register',
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
            $('#tableUsers').DataTable().ajax.reload();
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