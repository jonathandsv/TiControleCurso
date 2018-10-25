
 
var iddamateria = 0;
var iddauia = 0;
var aulas = [];
var inputsAulas;
//var inputsVas = document.getElementsByClasseName("in");
var comandoSalvar = 0;

$(".botaoSalvar").click(function () {
    iddauia = $(this).attr('iddauia');
    iddamateria = $(this).attr('iddamateria');
    comandoSalvar = $(this).attr('iddocomando');
    if (comandoSalvar = 1) {
        SalvarAulas();
    }
    if (comandoSalvar = 2) {
        SalvarVas();
    }
    if (comandoSalvar = 3) {
        SalvarForum();
    }
    if (comandoSalvar = 4) {
        SalvarExercicios();
    }
})

//Aulas

function SalvarAulas() {
    inputsAulas = document.getElementsByClassName("aulasuia" + iddauia);
    VerificarAulas();
    $.ajax({
        type: 'GET',
        url: 'Home/InserirAulas',
        dataType: 'json',
        data: { listaAulas: JSON.stringify(aulas) },
        success: function () {
            alert("salvo");
        },
        erro: function (e) {
            console.log(e);
        }
    });
};

function VerificarAulas() {
    var i = 0;
    
    for (i = 0; i < inputsAulas.length; i++) {

        var naula = parseInt(inputsAulas[i].id.slice(4, 5));
        if ($("#aula" + naula + "uia" + iddauia).prop('checked') == true) {
            var aula = {};
            aula.NomeAula = "Aula" + naula;
            aula.Status = "Completa";
            aula.IdUsuario = 1;
            aula.Uia = "UIA " + iddauia;
            aula.Materia = iddamateria;
            aula.Construcao = naula + iddauia + iddamateria;

            aulas.push(aula);
        }
    }
};

//Fim Aulas 







