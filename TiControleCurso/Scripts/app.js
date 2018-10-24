

var iddamateria = 0;
var iddauia = 0;
var aulas = [];
var inputs = document.getElementsByClassName("aulauia1");

$(".botaoSalvar").click(function () {
    iddauia = $(this).attr('iddauia');
    iddamateria = $(this).attr('iddamateria');
    VerificarAulas();
    $.ajax({
        type: 'GET',
        url: 'Home/InserirAulas',
        dataType: 'json',
        data: JSON.stringify(aulas),
        success: function () {
            alert("salvo");
        },
        erro: function (e) {
            console.log(e);
        }
    });

})

function VerificarAulas() {
    var i = 0;
    
    for (i = 0; i < inputs.length; i++) {
        var naula = 1 + i;
        if ($("#aula" + naula + "uia" + iddauia + "").prop('checked') == true) {
            var aula = {
                NomeAula: "Aula" + naula + "",
                Status: "Completa",
                IdUsuario: 1,
                Uia: "UIA " + iddauia + "",
                Materia: iddamateria
            };
            aulas.push(aula);
        }
    }
};



