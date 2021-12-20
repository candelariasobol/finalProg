$(document).ready(function(){
    $.ajax({
        URL: "https://localhost:5001/Mascotas/ObtenerPerros/RazaPerros",
        type: "GET",
        success: function(result){
            if(result.ok){
                resultadoRaza = result.return;
                cargarCombo(resultadoRaza);
            } else{
                
            }
        }
    })
})