$('#tabla').DataTable({
    responsive: {
        details: {
            renderer: function ( api, rowIdx, columns ) {
                var data = $.map( columns, function ( col, i ) {
                    return col.hidden ?
                    '<div class="d-flex flex-wrap me-3"><div class="border border-secondary  bg-primary text-white fw-bold px-3 py-1">'+col.title+'</div><div class="border border-secondary px-2 py-1">'+col.data+'</div></div>':
                        '';
                } ).join('');
 
                return data ?
                    $('<div class="w-100 d-flex flex-wrap"/>').append( data ) :
                    false;
            }
            //display: $.fn.dataTable.Responsive.display.modal()
        }
    },
    columnDefs:[
        {responsivePriority:1,targets:[0,2,4,6]}]
});