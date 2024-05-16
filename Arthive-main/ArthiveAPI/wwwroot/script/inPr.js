import axios from 'https://cdn.jsdelivr.net/npm/axios@1.3.5/+esm';
const more_dis = document.getElementById("more_dis")
const more_prog = document.getElementById("more_prog")
const more_front = document.getElementById("more_front")
const more_back = document.getElementById("more_back")

const profile = document.getElementById('profile')
const write = document.getElementById('write')
const to_main = document.getElementById('to_main')

const dis = document.getElementById('dis')
const prog = document.getElementById('prog')
const front = document.getElementById('front')
const bac = document.getElementById('bac')





/*Навигация*/
to_main.addEventListener('click', function() {
    window.location = 'main.html'
});

profile.addEventListener('click', function() {
    window.location = 'profile.html'
});

write.addEventListener('click', function() {
    window.location = 'write.html'
});

/*боковое*/
dis.addEventListener('click', function() {
    list(dis)
});

prog.addEventListener('click', function() {
    list(prog)
});

front.addEventListener('click', function() {
    list(front)
});

bac.addEventListener('click', function() {
    list(bac)
});

function list(elem){
    let choice = document.createElement('select')
    choice.classList.add('way')
    choice.innerHTML = `
    <option value="статьи">Статьи</option>
    <option value="статьи">Материалы</option>
    <option value="статьи">Книги</option>`
    elem.append(choice)
}

/*попытки связать*/
async function gett(){
    const res = await axios.post('http://localhost:5182/pc/post/recomendation')
    display(res);
}

function display(data){
    data.forEach(element => {
        let cont = document.createElement("div");
        cont.classList.add('stat')
        task.innerHTML = `
        <img class="screen" src="${element.PictureURL}">
        <p class="name">${element.PostName}</p>
        <img class="class" src="main_in_profile/static/easy.svg">`;
        document.getElementById("stats").append(cont)
})}

gett()

more_dis.addEventListener('click', function() {
    localStorage.setItem('major', "design"),
    window.location = 'article.html'
});

more_prog.addEventListener('click', function() {
    localStorage.setItem('major', "programming"),
    window.location = 'article.html'
});

more_front.addEventListener('click', function() {
    localStorage.setItem('major', "frontend"),
    window.location = 'article.html'
});

more_back.addEventListener('click', function() {
    localStorage.setItem('major', "backend"),
    window.location = 'article.html'
});


