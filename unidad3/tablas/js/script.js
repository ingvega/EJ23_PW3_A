var datos1=[];
datos1[0]=[];
datos1[0][0]="juan"; datos1[0][1]="perez";

var datos2=[]; datos2[0]=[];
datos2[0]["nombre"]="juan"; datos2[0]["apellidos"]="perez";
var datos3=[]; datos3[0]={};
datos3[0].nombre="juan";
datos3[0].apellidos="perez";
datos3[0].email="perez@gmail.com";
datos3[1]={nombre:"alberto",apellidos:"medina",
email:"medina@gmail.com"};

console.log(datos1);
console.log(datos2);
console.log(datos3);

window.onload=()=>{
    $("#tablaPersonas").DataTable({
        data:datos3,
        columns:[
            {
                title:'Nombre',data:'nombre'
            },
            {
                title:'Apellidos',data:'apellidos'
            },
            {
                title:'Correo electrónico',data:'email'
            }
        ]
    });
};
