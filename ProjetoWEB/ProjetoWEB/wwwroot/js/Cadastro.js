
function validarFormulario(event) {
    var senha = document.getElementById('senha').value;
    var senhaRepetida = document.getElementById('senhaRepetida').value;
    var email = document.getElementById('email').value;

    var dataNascimento = document.getElementById('dataNascimento').value;
    var dataAtual = new Date();
    var dataNascimentoDate = new Date(dataNascimento);
    var idade = dataAtual.getFullYear() - dataNascimentoDate.getFullYear();
    var mes = dataAtual.getMonth() - dataNascimentoDate.getMonth();
    if (mes < 0 || (mes === 0 && dataAtual.getDate() < dataNascimentoDate.getDate())) {
        idade--;
    }

    var erroEmail = document.getElementById('erroEmail');
    var erroSenha = document.getElementById('erroSenha');
    var erroSenhaRepetida = document.getElementById('erroSenhaRepetida');
    var erroData = document.getElementById('erroData');

    var regex = /^(?=.*[!@#$%^&*(),.?":{}|<>])(?=.*[a-z])(?=.*[A-Z])[^\s]{8,}$/;

    erroEmail.innerText = '';
    erroSenha.innerText = '';
    erroSenhaRepetida.innerText = '';
    erroData.innerText = '';

    if (dataNascimento.length == 0)
        erroData.innerText = 'Por favor, insira uma data de nascimento!';
    else if (idade < 12 || idade > 80)
        erroData.innerText = 'Por favor, insira uma data de nascimento maior de 12 anos ou menor que 80 anos!';

    if (email.length == 0)
        erroEmail.innerText = 'Por favor, insira um email!';
    else if (email.indexOf('@') == -1)
        erroEmail.innerText = 'O Email está faltando "@"';
    else if (email.indexOf('@') < 1 || email.indexOf('@') == email.length - 1)
        erroEmail.innerText += 'O formato do Email está incorreto!';

    if (!regex.test(senha)) {
        erroSenha.innerText = 'A senha deve conter no mínimo 8 caracteres, um símbolo especial ( !@#$%^&(),.? ) e uma letra minúscula e maiúscula';
    }
    if (senha !== senhaRepetida) {
        erroSenha.innerText = 'As senhas não correspondem. Por favor, tente novamente.';
        erroSenhaRepetida.innerText = 'As senhas não correspondem. Por favor, tente novamente.';
    }

    if (erroEmail.innerText.length != 0 || erroSenha.innerText.length != 0 || erroSenhaRepetida.innerText.length != 0 || erroData.innerText.length != 0) {
        event.preventDefault(); // Impede o envio do formulário
    }
}


// Adiciona um evento de envio ao formulário após o carregamento da página
document.addEventListener('DOMContentLoaded', function () {
    var form = document.getElementById('cadastroForm');
    form.addEventListener('submit', validarFormulario);
});
