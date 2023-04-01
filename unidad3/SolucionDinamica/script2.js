$('#tabla').DataTable({
    /*responsive: {
        details: {
            //display: $.fn.dataTable.Responsive.display.modal()
            display: $.fn.dataTable.Responsive.display.childRowImmediate
        }
    },*/
    //responsive: true,
    responsive: {
        details: {
            renderer: function ( api, rowIdx, columns ) {
                var data = $.map( columns, function ( col, i ) {
                    return col.hidden ?
                        '<div class="d-flex border" data-dt-row="'+col.rowIndex+'" data-dt-column="'+col.columnIndex+'">'+
                            '<div class="p-2 bg-primary text-white">'+col.title+':'+'</div> '+
                            '<div class="p-2">'+col.data+'</div>'+
                        '</div>' :
                        '';
                } ).join('');

                return data ?
                    $('<div class="d-flex flex-wrap justify-content-evenly" />').append( data ) :
                    false;
            }
        }
    },
    columnDefs:[
        {responsivePriority:1,targets:[0,2,4,6]}]
});