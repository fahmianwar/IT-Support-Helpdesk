$(document).ready(function () {
    var i = 1;
    console.log("Coba");
    $('#tableCases').DataTable({
        ajax: {
            url: 'https://localhost:44357/Panel/GetCases',
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
                "data": "description"
            },
            {
                "data": "startDateTime"
            },
            {
                "data": "endDateTime"
            },
            {
                "data": "review"
            },
            {
                "data": "level"
            },
            {
                "data": "userId"
            },
            {
                "data": "priorityId"
            },
            {
                "data": "categoryId"
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-primary" onclick="detailCases('${row['id']}')" data-bs-toggle="modal" data-bs-target="#detailModal">Detail</button> | <button type="button" class="btn btn-info" onclick="editCase('${row['id']}')" data-bs-toggle="modal" data-bs-target="#editModal">Edit</button> | <button type="button" class="btn btn-danger" onclick="deleteCase('${row['id']}')">Delete</button>`;
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
    var obj = new Object();
    obj.Description = $("#inputDescription").val();
    obj.StartDateTime = $("#inputStartDate").val();
    obj.EndDateTime = $("#inputEndDate").val();
    obj.Review = parseInt($("#inputReview").val());
    obj.Level = parseInt($("#inputLevel").val());
    obj.UserId = parseInt($("#inputUserId").val());
    obj.PriorityId = parseInt($("#inputPriorityId").val());
    obj.CategoryId = parseInt($("#inputCategoryId").val());
    console.log(obj);
    console.log(JSON.stringify(obj));
    if (obj.Description == "" || obj.StartDateTime == "" || obj.EndDateTime == "" || obj.Review == "" || obj.Level == "" || obj.UserId == "" || obj.PriorityId == "" || obj.CategoryId == "") {
        Swal.fire({
            title: 'Error!',
            text: 'Failed create user',
            icon: 'error',
            confirmButtonText: 'OK'
        });
    } else {
        $.ajax({
            url: 'https://localhost:44357/api/cases',
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