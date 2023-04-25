document.addEventListener("DOMContentLoaded",()=>{
    //Definir los keyframes
    let rotar=[
        { transform: 'rotateX(90deg)' },
        { transform: 'rotateX(0deg)' }
    ];

    //Configurar la animación
    let config={
        duration:1000
    };

    //console.log(document.querySelector(".texto div"));
    
    let letras=document.querySelectorAll(".texto div");
    console.log(letras);
    letras.forEach((e,i)=>{
        console.log(e);
        console.log(i);
        e.animate(rotar,config);
    });

});