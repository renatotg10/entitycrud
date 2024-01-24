$(document).ready(function () {
    getDataTable('#emprestimos');
    getDataTable('#usuarios');

    function getDataTable(id) {
        $(id).DataTable({
            language: {
                "decimal": "",
                "emptyTable": "Nenhum registro encontrado na tabela",
                "info": "Mostrando _START_ registro de _END_ em um total de _TOTAL_ entradas",
                "infoEmpty": "Mostrando 0 de 0 registros",
                "infoFiltered": "(filtered from _MAX_ total entries)",
                "infoPostFix": "",
                "thousands": ",",
                "lengthMenu": "Mostrar _MENU_ entradas",
                "loadingRecords": "Carregando...",
                "processing": "",
                "search": "Procurar:",
                "zeroRecords": "Nenhum registro encontrado",
                "paginate": {
                    "first": "Primeiro",
                    "last": "Último",
                    "next": "Próximo",
                    "previous": "Anterior"
                },
                "aria": {
                    "sortAscending": ": Ordenar colunas de forma ascendente",
                    "sortDescending": ": Ordenar colunas de forma descendente"
                }

            }
        });
    }

    setTimeout(function () {
        $(".alert").fadeOut("slow", function () {
            $(this).alert('close');
        })
    }, 3000)

});
