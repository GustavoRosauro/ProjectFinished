$(document).ready(function () {
    //$("#cnpj").keypress(verificaNumero);
    $("#salvar").click(function () {
        if ($("#cnpj").val().length < 14 && $("#cnpj").val().length !== 11) {

            alert("CPF ou CNPJ Invalido");
        } else {
            if ($("#cnpj").val().length === 11 && $("#rg").val() == "") {
                alert("Você não colocou seu RG");
            } else {
                $.ajax({
                    type: "POST",
                    url: "/Empresa/SalvaFornecedor",
                    data: {
                        "nome": $("#nome").val(),
                        "cnpj": $("#cnpj").val(),
                        "Telefone": $("#telefone").val(),
                        "rg": $("#rg").val(),
                        "nascimento": $("#nascimento").val(),
                        "estado": $("#estado").val(),
                        "id": $("#idEmpresa").val()
                    },
                    success:
                        function () {
                            alert("Salvo com Suceso");
                            window.location = "/Empresa/Index"
                        },
                    error: function () {
                        alert("Você é menor de idade");
                    }
                })
            }
        }
    });
    function limitaInput() {
        document.getElementById("cnpj").value = document.getElementById("cnpj").value.substr(0, 14);
    }
    function verificaNumero(e) {
        //limitaInput();
        //if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
        //    return false;
        //}
    }
});