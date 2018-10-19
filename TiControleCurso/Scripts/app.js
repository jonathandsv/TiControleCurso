//Aulas 

//var aulasuia1 = [
//                    $("#aula1uia1").prop('checked'),
//                    $("#aula2uai1").prop('checked'),
//                    $("#aula3uai1").prop('checked'),
//                    $("#aula4uai1").prop('checked')
//];
//var aula1 = $("#aula1uia1").prop('checked');
//var aula2 = $("#aula2uai1").prop('checked');
//var aula3 = $("#aula3uai1").prop('checked');
//var aula4 = $("#aula4uai1").prop('checked');


$(".botaoSalvar").click(function () {
    iddauia = $(this).attr('iddauia');
    iddamateria = $(this).attr('iddamateria');
    VerificarAulas();
    $.ajax({
        type: 'POST',
        url: '',
        dataType: 'json',
        data: { ListadeObjetos: aulasuaia1 },
        success: function () {

        },
        erro: function (e) {
            console.log(e);
        }
    });

});
var iddamateria = 0;
var iddauia = 0;
var aulas = [];
var inputs = $("input[name=aulauia1]");

function VerificarAulas() {
    var i = 0;
    var naula = 1 + i;
    for (i = 0; i < inputs.length; i++) {
        if ($("#aula" + naula + "uia1").prop('checked') == true) {
            var aula = {
                Nome: "Aula" + naula + "",
                UIA: "UIA " + iddauia + "",
                Status: "Completa",
                Materia: iddamateria 
            };
            aulas.push(aula);
        }
    }
};

