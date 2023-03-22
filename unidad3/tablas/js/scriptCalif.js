$(document).ready(()=>{
    $("#calificaciones").DataTable({
        responsive: true,
        columnDefs:[
            {responsivePriority:2,targets:0},
            {responsivePriority:1,targets:[1,2,3,4,5,6,7,8,9,10,11]}
        ]
    });
});