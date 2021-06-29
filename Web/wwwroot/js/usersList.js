$(document).ready(function () {
    var i = 1;
    $('#tableUsers').DataTable({
        ajax: {
            url: 'https://localhost:44357/Panel/GetUsers',
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
                "data": "roleId"
            },
            {
                "render": function (data, type, row) {
                    return `<button type="button" class="btn btn-primary" onclick="detailProfile('${row['id']}')" data-bs-toggle="modal" data-bs-target="#detailModal">Detail</button> | <button type="button" class="btn btn-info" onclick="editProfile('${row['id']}')" data-bs-toggle="modal" data-bs-target="#editModal">Edit</button> | <button type="button" class="btn btn-danger" onclick="deleteProfile('${row['id']}')">Delete</button>`;
                }
            }
        ]
    });

});