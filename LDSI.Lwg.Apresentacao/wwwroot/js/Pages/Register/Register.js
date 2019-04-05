function showCamposCadastro()
{
    document.getElementById("tipo_cadastro").style.display = 'none';
    document.getElementById("campos_cadastro").style.display = 'block';
}

function tipoDeCadastroClick(EhAluno) {
    if (EhAluno) {
        document.getElementById("curso_aluno").style.display = 'block';
    } else {
        document.getElementById("curso_aluno").style.display = 'none';
    }
}