$(document).ready(function () {
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
                    return `<button type="button" class="btn btn-primary" onclick="detailStatusCodes('${row['id']}')" data-bs-toggle="modal" data-bs-target="#detailModal">Detail</button> | <button type="button" class="btn btn-info" onclick="editStatusCodes('${row['id']}')" data-bs-toggle="modal" data-bs-target="#editModal">Edit</button> | <button type="button" class="btn btn-danger" onclick="deleteStatusCodes('${row['id']}')">Delete</button>`;
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
            $('#tablePriorities').DataTable().ajax.reload();
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