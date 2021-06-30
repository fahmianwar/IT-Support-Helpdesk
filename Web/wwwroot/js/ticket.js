function createTicket() {
    var obj = new Object();
    obj.UserId = parseInt($("#inputCreateUserId").val());
    obj.Description = $("#inputCreateDescription").val();
    obj.CategoryId = parseInt($("#inputCreateCategoryId ").val());
    obj.Message = $("#inputCreateMessage").val();
    //console.log(obj);
    //console.log(JSON.stringify(obj));
    if (obj.UserId < 0 || obj.Description == "" || obj.CategoryId == "" || obj.Message == "") {
        Swal.fire({
            title: 'Error!',
            text: 'Failed create user',
            icon: 'error',
            confirmButtonText: 'OK'
        });
    } else {
        $.ajax({
            url: 'https://localhost:44381/api/Cases/CreateTicket',
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