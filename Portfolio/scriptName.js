const sections = document.querySelectorAll('.section');
const sectBtn = document.querySelectorAll(".control");
const allsections = document.querySelector('.main-content');

function changeClass(){

   for(let i = 0; i < sectBtn.length ; i++){
       sectBtn[i].addEventListener('click' , function(){
           activeBtn = document.getElementsByClassName('active-btn');
           activeBtn[0].classList.remove("active-btn");
           sectBtn[i].classList.add("active-btn");
       })
   }

   allsections.addEventListener('click' , function(e){
       const id = e.target.dataset.id;
       const element = document.getElementById(id);
       if(id){  document.querySelector('.active').classList.remove('active');
       element.classList.add('active');
    }
   })

   const themeBtn = document.querySelector('.theme-btn');
   themeBtn.addEventListener('click' , ()=>{
       let element = document.body;
       element.classList.toggle('light-mode');
   })
}


changeClass();
