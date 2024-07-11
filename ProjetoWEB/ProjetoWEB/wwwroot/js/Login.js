
function validarFormulario(event) {
    var email = document.getElementById('email').value;
    var senha = document.getElementById('senha').value;
    var erroSenha = document.getElementById('erroSenha');
    var erroEmail = document.getElementById('erroEmail');

    erroSenha.innerText = '';
    erroEmail.innerText = '';
    if (email.length == 0) 
        erroEmail.innerText = 'Por favor, insira um email!';
    else if (email.indexOf('@') == -1) 
        erroEmail.innerText = 'O Email Esta faltando "@".'; 
    else if (email.indexOf('@') < 1 || email.indexOf('@') == email.length - 1) 
        erroEmail.innerText = 'O formato do Email esta incorreto!';     
    
    if (senha.length == 0) 
        erroSenha.innerText = 'Por favor, insira uma senha!';

    if (erroEmail.innerText.length != 0 || erroSenha.innerText.length != 0)
        event.preventDefault(); 

        
}

// Adiciona um evento de envio ao formulário após o carregamento da página
document.addEventListener('DOMContentLoaded', function () {
    var form = document.getElementById('loginForm');
    form.addEventListener('submit', validarFormulario);
});

