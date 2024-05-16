const write = document.getElementById('write')
const to_main = document.getElementById('to_main')
const back = document.getElementById('back')

const read = document.getElementById('read')

const dis = document.getElementById('dis')
const prog = document.getElementById('prog')
const front = document.getElementById('front')
const bac = document.getElementById('bac')

/*Навигация*/
back.addEventListener('click', function() {
    window.history.go(-1);
});

to_main.addEventListener('click', function() {
    window.location = 'main.html'
});

write.addEventListener('click', function() {
    window.location = 'write.html'
});

read.addEventListener('click', function() {
    window.location = 'article.html'
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