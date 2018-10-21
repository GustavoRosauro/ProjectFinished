$(document).ready(function () {

    $("#cnpj").keypress(verificaNumero);
    $("#salvar").click(function () {
        if ($("#cnpj").val().length < 14) {
            alert("CNPJ Invalido");
        } else {
            $.ajax({
                type: "POST",
                url: "/Empresa/SalvaEmpresa",
                data: {
                    "nome": $("#nome").val(),
                    "cnpj": $("#cnpj").val(),
                    "UF": $("#UF").val()
                },
                success:
                    function () {
                        alert("Salvo com Suceso");
                        window.location = "/Empresa/Index"
                    }
            })
        }
    });
    function limitaInput() {
            document.getElementById("cnpj").value = document.getElementById("cnpj").value.substr(0,14) ;
    }
    function verificaNumero(e) {
        //limitaInput();
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    }
});