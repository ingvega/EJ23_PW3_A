var animaciones=[];
function disminuir(){
animaciones.forEach((animacion)=>{
    console.log(animacion);
    debugger;
});

}
document.addEventListener("DOMContentLoaded",()=>{

    //Definir los keyframes
    let rotar=[
        { transform: 'rotateX(80deg)' },
        { transform: 'rotateX(0deg)' }
    ];

    let duracion=100;
    //Configurar la animación
    let config={
       // iterations:Infinity,
        delay:0,
        duration:1000,
        fill:'forwards'
    };
    
    //console.log(document.querySelector(".texto div"));
    let letras=document.querySelectorAll(".texto div");
    console.log(letras);
    letras.forEach((e,i)=>{
    
        console.log(e);
        console.log(i);
        config.iterations = Infinity;
        config.delay=duracion*i;
        animaciones.push(e.animate(rotar,config));
    });

});