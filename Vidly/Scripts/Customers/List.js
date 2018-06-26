$(document).ready(function () {
    var table = $("#customers").DataTable({
        "language": {
            "search": "Buscar: ",
            "paginate": {
                "previous": "Anterior",
                "next": "Próximo"
            }
        },
        "info": false,
        "bLengthChange": false,
        ajax: {
            url: "/api/customers/",
            dataSrc: ""
        },
        columns: [
            {
                className: "align-middle text-center",
                data: "name",
                render: function (data, type, customer) {
                    return "<a href='/customers/edit/" +
                        customer.id +
                        "' class='btn btn-link'>" +
                        data +
                        "</a>";
                }
            },
            {
                className: "align-middle text-center",
                data: "membershipType.name"
            },
            {
                className: "align-middle text-center",
                data: "id",
                render: function (data) {
                    return "<button class='btn btn-danger js-delete' data-customer-id='" +
                        data +
                        "'><i class='fas fa-trash'></i></button>";
                },
                width: "20%"
            }
        ]
    });

    $("#customers").on("click",
        ".js-delete",
        function () {
            var button = $(this);

            bootbox.confirm({
                message: "Tem certeza que deseja excluir este cliente? Essa ação não pode ser revertida.",
                backdrop: true,
                onEscape: function () { },
                callback: function (result) {
                    if (result) {
                        $.ajax({
                            url: "/api/customers/" + button.attr("data-customer-id"),
                            method: "DELETE",
                            success: function() {
                                toastr.success("Cliente excluído com sucesso!");
                                table.row(button.parents("tr")).remove().draw();
                            },
                            error: function() {
                                toastr.error("Algum erro inexperado ocorreu.");
                            }
                        });
                    }
                }
            });
        });
});