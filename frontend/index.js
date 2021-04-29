
function getCargos(callback) {

    var Cargos = fetch('http://localhost:33553/api/cargos')
        .then(response => response.json())
        .then(data => {
            callback(data)
        });

}


function getselectCardeps() {
    document.getElementById("cuerpo").innerHTML = "";

    var cbocargo = document.getElementById("selCargo");
    var cbodepto = document.getElementById("selDepartamento");


    fetch('http://localhost:33553/api/Nominas/' + cbocargo.options[cbocargo.selectedIndex].value + "/" + cbodepto.options[cbodepto.selectedIndex].value)
        .then(response => response.json())
        .then(data => {
            for (let index = 0; index < data.length; index++) {
                const item = data[index]; 

                    document.getElementById("cuerpo").innerHTML += "<tr><th>" + item.cargo +
                        "<th>" + item.departamento +
                        "</th>" + "<th>" + item.nombre +
                        "</th>" + "<th>" + item.sueldo +
                        "</th>" + "<th>" + item.ano +
                        "</th>" + "<th>" + item.mes +
                        "</th>" + "</th></tr>"

                
            }

        });


    // if (text != "Elija" && text2 != "Elija") 
    // {

    // var Cargos = fetch('http://localhost:33553/api/cargos/GetCargosbyCargos/' + cbocargo.options[cbocargo.selectedIndex].innerText)
    //     .then(response => response.json())
    //     .then(data => {
    //         if (text2 != null) {
    //             for (let index = 0; index < data.length * 0.5; index++) {
    //                 const item = data[index];
    //                 var Departamento = fetch('http://localhost:33553/api/Nominas/GetNominasByDept/' + cbodepto.options[cbodepto.selectedIndex].innerText)
    //                     .then(response => response.json())
    //                     .then(data => {
    //                         var Departamento = fetch('http://localhost:33553/api/Nominas/' + item.cargoId + "/" + text2)
    //                             .then(response => response.json())
    //                             .then(data => {
    //                                 for (let index = 0; index < data.length; index++) {
    //                                     const item2 = data[index]; debugger
    //                                     if (item2.departamento == text2) {
    //                                         debugger
    //                                         document.getElementById("cuerpo").innerHTML += "<tr><th>" + item.cargos +
    //                                             "<th>" + item2.departamento +
    //                                             "</th>" + "<th>" + item2.nombre +
    //                                             "</th>" + "<th>" + item2.sueldo +
    //                                             "</th>" + "<th>" + item2.ano +
    //                                             "</th>" + "<th>" + item2.mes +
    //                                             "</th>" + "</th></tr>"

    //                                     }
    //                                 }
    //                             });

    //                     });
    //             }
    //         }
    //     });
    // }



    // else if (text != "Elija") {
    //     var Cargos = fetch('http://localhost:33553/api/cargos/GetCargosbyCargos/' + text)
    //         .then(response => response.json())
    //         .then(data => {
    //             if (text2 != null) {
    //                 for (let index = 0; index < data.length * 0.5; index++) {
    //                     const item = data[index];
    //                     var Departamento = fetch('http://localhost:33553/api/Nominas/GetNominasByCargoId/' + item.cargoId)
    //                         .then(response => response.json())
    //                         .then(data => {
    //                             for (let index = 0; index < data.length; index++) {
    //                                 const item2 = data[index];
    //                                 if (text2 != null) {
    //                                     document.getElementById("cuerpo").innerHTML += "<tr><th>" + item.cargos +
    //                                         "<th>" + item2.departamento +
    //                                         "</th>" + "<th>" + item2.nombre +
    //                                         "</th>" + "<th>" + item2.sueldo +
    //                                         "</th>" + "<th>" + item2.ano +
    //                                         "</th>" + "<th>" + item2.mes +
    //                                         "</th>" + "</th></tr>"

    //                                 }
    //                             }
    //                         });

    //                 }
    //             }
    //         });
    // }
    // else if (text2 != "Elija") {
    //     debugger
    //     var Departamento = fetch('http://localhost:33553/api/Nominas/GetNominasByDept/' + text2)
    //         .then(response => response.json())
    //         .then(data => {
    //             for (let index = 0; index < data.length; index++) {
    //                 const item22 = data[index];
    //                 var Departamento = fetch('http://localhost:33553/api/cargos/GetCargosbyCargoId/' + item22.cargoId)
    //                     .then(response => response.json())
    //                     .then(data => {
    //                         for (let index = 0; index < data.length * 0.5; index++) {

    //                             const item2 = data[index];
    //                             if (text2 != null) {
    //                                 document.getElementById("cuerpo").innerHTML += "<tr><th>" + item2.cargos +
    //                                     "<th>" + item22.departamento +
    //                                     "</th>" + "<th>" + item22.nombre +
    //                                     "</th>" + "<th>" + item22.sueldo +
    //                                     "</th>" + "<th>" + item22.ano +
    //                                     "</th>" + "<th>" + item22.mes +
    //                                     "</th>" + "</th></tr>"

    //                             }
    //                         }
    //                     });

    //             }
    //         });

    // }
}


/*
function getselectCargos(){
    document.getElementById("cuerpo").innerHTML = "";
    var select = document.getElementById("selCargo1"), 
        value = select.value, 
        text = select.options[select.selectedIndex].innerText;
        if(text != null){
       var Cargos = fetch('http://localhost:33553/api/cargos/GetCargosbyCargos/'+text)
        .then(response => response.json())
        .then(data =>    {
        for (let index = 0; index < data.length*0.5; index++) {  
            const item = data[index];
            var Departamento = fetch('http://localhost:33553/api/Nominas/GetNominasByCargoId/'+item.cargoId)
        .then(response => response.json())
        .then(data => {for (let index = 0; index < data.length; index++) {  
            const item2 = data[index];
            if(text != null){
            document.getElementById("cuerpo").innerHTML += "<tr><th>"+item.cargos +
            "<th>"+item2.departamento +
            "</th>"+"<th>"+item2.nombre +
            "</th>"+"<th>"+item2.sueldo +
            "</th>"+"<th>"+item2.ano +
            "</th>"+"<th>"+item2.mes +
            "</th>"+"</th></tr>"
    
        }}});

        }

    }

);
    
}
}
*/
/*
function getselectDep(){
    document.getElementById("cuerpo").innerHTML = "";
        var select2 = document.getElementById("selDepartamento1"), 
        value2 = select2.value, 
        text2 = select2.options[select2.selectedIndex].innerText;
        console.log(text2);
        if(text2 != null){
            var Departamento = fetch('http://localhost:33553/api/Nominas/GetNominasByDepartamento/'+text2)
        .then(response => response.json())
        .then(data =>    {console.log(data);
        for (let index = 0; index < data.length; index++) {
         
            const item = data[index];
            var Cargos = fetch('http://localhost:33553/api/cargos/GetCargosbyCargoId/'+item.cargoId)
            
        .then(response => response.json())
        .then(data => {for (let index = 0; index < data.length*0.5; index++) {  
            const item2 = data[index];
            if(text2 != null){
            document.getElementById("cuerpo").innerHTML += "<tr><th>"+item2.cargos +
            "<th>"+item.departamento +
            "</th>"+"<th>"+item.nombre +
            "</th>"+"<th>"+item.sueldo +
            "</th>"+"<th>"+item.ano +
            "</th>"+"<th>"+item.mes +
            "</th>"+"</th></tr>"
    
        }}});

        }

    }

);
    
}
}
*/

const selcargo = document.getElementById("selCargo");

getCargos(cargos => {
    var opt = document.createElement("option");
    opt.value = -1;
    opt.innerHTML = "Elija";
    selcargo.appendChild(opt);


    for (let index = 0; index < cargos.length; index++) {
        const item = cargos[index];

        var opt = document.createElement("option");
        opt.value = item.cargoId;
        opt.innerHTML = item.cargos;
        selcargo.appendChild(opt);

    }


}

);



function getDepartamentos(callback) {

    var Departamento = fetch('http://localhost:33553/api/Nominas/GetNominasByDepartamento')
        .then(response => response.json())
        .then(data => {
            callback(data)
        });

}


/*
const selDepartamento = document.getElementById("selDepartamento");
function getdepCarg(){
    var select = document.getElementById("selCargo"), 
    value = select.value, 
    text = select.options[select.selectedIndex].innerText;
console.log(text);
    var Departamento = fetch('http://localhost:33553/api/cargos/GetCargosbyCargos/'+text)
        .then(response => response.json())
        .then(data => {for (let index = 0; index < data.length*0.5; index++) {  
            const item2 = data[index];
            
            
            var Departamento = fetch('http://localhost:33553/api/Nominas/GetNominasByDepartamento/')
            .then(response => response.json())
            .then(data => {
                console.log(data);
                for (let index = 0; index < data.length; index++) {
                    const item = data[index];
        
                    var opt = document.createElement("option");
                    //if(opt.value != item){
                    opt.value = item;
                    opt.innerHTML = item;
                    selDepartamento.appendChild(opt);
                //}
            }});
            
        }});
          
        document.getElementById("dev").style.display = "inline"
       

}
*/

const selDepartamento1 = document.getElementById("selDepartamento");
getDepartamentos(Nominas => {


    var opt = document.createElement("option");
    opt.innerHTML = "Elija";
    opt.value = "elija";
    selDepartamento1.appendChild(opt);

    for (let index = 0; index < Nominas.length; index++) {
        const item = Nominas[index];
        var opt = document.createElement("option");
        opt.value = item;
        opt.innerHTML = item;
        selDepartamento1.appendChild(opt);

    }

});



