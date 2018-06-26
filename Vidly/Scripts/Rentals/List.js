$(document).ready(function() {
    var table = $("#rentals").DataTable({
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
            url: "/api/rentals/",
            dataSrc: ""
        },
        columns: [
            {
                className: "align-middle text-center",
                data: "id",
                width: "10%"
            },
            {
                className: "align-middle text-center",
                data: "customer.name",
                render: function(data, type, rental) {
                    return "<a href='/rentals/edit/" +
                        rental.id +
                        "' class='btn btn-link'>" +
                        data +
                        "</a>";
                }
            },
            {
                className: "align-middle text-center",
                data: "movie.name"
            },
            {
                className: "align-middle text-center",
                data: "rentedDate",
                render: function(data) {
                    return formatDate(data);
                }
            },
            {
                className: "align-middle text-center",
                data: "id",
                render: function (data, type, rental) {
                    console.log(rental);
                    return "<button class='btn btn-success js-checkin' data-rental-id='" +
                        data +
                        "'><i class='fas fa-check'></i></button>";
                },
                width: "20%"
            }
        ]
    });

    $("#rentals").on("click",
        ".js-checkin",
        function () {
            var button = $(this);

            bootbox.confirm("Deseja realizar o CheckIn dessa locação? Essa ação não pode ser revertida!",
                function(result) {
                    if (result) {
                        $.ajax({
                            url: "/api/rentals/checkin" + button.attr("data-rental-id"),
                            method: "PUT",
                            success: function() {
                                toastr.success("Locação finalizada com sucesso!");
                                table.row(button.parents("tr")).remove().draw();
                            },
                            error: function() {
                                toastr.error("Algum erro inexperado ocorreu.");
                            }
                        });
                    }
                });
        }
    );
});

function formatDate(date) {
    var typedDate = new Date(date);
    var dia = typedDate.getDate();
    if (dia.toString().length === 1)
        dia = "0" + dia;
    var mes = typedDate.getMonth() + 1;
    if (mes.toString().length === 1)
        mes = "0" + mes;
    var ano = typedDate.getFullYear();
    return dia + "/" + mes + "/" + ano;
}