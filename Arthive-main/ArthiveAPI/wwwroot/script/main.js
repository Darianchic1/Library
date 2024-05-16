const major = document.querySelectorAll("major")
const enter = document.getElementById("enter")

enter.addEventListener('click', function() {
    window.location = 'login.html'
});

const dis = document.getElementById('dis')
const prog = document.getElementById('prog')
const front = document.getElementById('front')
const bac = document.getElementById('bac')

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
