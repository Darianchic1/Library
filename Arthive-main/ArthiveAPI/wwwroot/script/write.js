import axios from 'https://cdn.jsdelivr.net/npm/axios@1.3.5/+esm';
const profile = document.getElementById('profile')
const to_main = document.getElementById('to_main')
const back = document.getElementById('back')

const dis = document.getElementById('dis')
const prog = document.getElementById('prog')
const front = document.getElementById('front')
const bac = document.getElementById('bac')

const spec = document.getElementById('spec')
const types = document.getElementById('types')
const name_cont = document.getElementById('name_cont')
const disc_cont = document.getElementById('disc_cont')
const img_cont = document.getElementById('img_cont')
const cont = document.getElementById('cont')
const time = document.getElementById('time')

const send_form = document.getElementById('send_form')

/*spec.addEventListener('focusout', function() {
    var spec_value = spec.value
});

types.addEventListener('focusout', function() {
    let types_value = types.value
});*/


/*Навигация*/
to_main.addEventListener('click', function() {
    window.location = 'main.html'
});

profile.addEventListener('click', function() {
    window.location = 'profile.html'
});

back.addEventListener('click', function() {
    window.history.go(-1);
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


async function write(category, type){
    const token = localStorage.getItem('token')
    console.log(token)
    await axios.post('http://localhost:5182/pc/post/create', {
        headers: {
            "Authorization": `Bearer ${token}`,
        },
        body: JSON.stringify(
            {
                "contents": [
                  {
                    "type": 0,
                    "data": "string",
                  }
                ],
                "postName": name_cont.value,
                "description": disc_cont.value,
                "pictureURL": img_cont.value,
                "category": category,
                "type": type,
                "averageTime": time.value
            }) 
    }
)}

send_form.addEventListener('click', function() {
    var spec_value = spec.value
    let types_value = types.value
    write(spec_value, types_value)
});


