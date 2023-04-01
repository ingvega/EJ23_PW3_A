$('#tabla').DataTable({
    responsive:true,
    columnDefs:[
        {responsivePriority:1,targets:[0,2,4,6]}]
});