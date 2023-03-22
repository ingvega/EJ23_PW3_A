$(document).ready(()=>{
    $("#calificaciones").DataTable({
        responsive: {
            details: {
                renderer: function ( api, rowIdx, columns ) {
                    var data = $.map( columns, function ( col, i ) {
                        return col.hidden ?
                            '<tr data-dt-row="'+col.rowIndex+'" data-dt-column="'+col.columnIndex+'">'+
                                '<td>'+col.title+':'+'</td> '+
                                '<td>'+col.data+'</td>'+
                            '</tr>' :
                            '';
                    } ).join('');
     
                    return data ?
                        $('<table/>').append( data ) :
                        false;
                }
                //display: $.fn.dataTable.Responsive.display.modal()
            }
        },
        columnDefs:[
            {responsivePriority:2,targets:0},
            {responsivePriority:1,targets:[1,2,3,4,5,6,7,8,9,10,11]}
        ]
    });
});