$(document).ready(function () {
    var table = $("#movies").DataTable({
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
            url: "/api/movies/",
            dataSrc: ""
        },
        columns: [
            {
                className: "align-middle text-center",
                data: "name",
                render: function (data, type, movie) {
                    return "<a href='/movies/edit/" +
                        movie.id +
                        "' class='btn btn-link'>" +
                        data +
                        "</a>";
                }
            },
            {
                className: "align-middle text-center",
                data: "genre.name"
            },
            {
                className: "align-middle text-center",
                data: "id",
                render: function (data) {
                    return "<button class='btn btn-danger js-delete' data-movie-id='" +
                        data +
                        "'><i class='fas fa-trash'></i></button>";
                },
                width: "20%"


            }
        ]
    });

    $("#movies").on("click",
        ".js-delete",
        function () {
            var button = $(this);

            bootbox.confirm("Deseja excluir este filme? Essa ação é irreversível",
                function (result) {
                    if (result) {
                        $.ajax({
                            url: "/api/movies/" + button.attr("data-movie-id"),
                            method: "DELETE",
                            success: function () {
                                toastr.success("Filme excluído com sucesso!");
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
})
