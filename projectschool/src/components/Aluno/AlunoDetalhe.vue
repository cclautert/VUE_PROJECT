<template>
  <div>
      <titulo  :texto="`Aluno: ${aluno.nome}`"/>
      <table>
          <tbody>
              <tr>
                  <td class="colPequeno"> Matrícula:</td>
                  <td>{{aluno.id}}</td>
              </tr>
              <tr>
                  <td>Nome:</td>
                  <td>{{aluno.nome}}</td>
              </tr>
              <tr>
                  <td>SobreNome:</td>
                  <td>{{aluno.sobrenome}}</td>
              </tr>
              <tr>
                  <td>Data Nescimento:</td>
                  <td>{{aluno.dataNasc}}</td>
              </tr>
              <tr>
                  <td>Professor:</td>
                  <td>{{aluno.professor.nome}}</td>
              </tr>
          </tbody>
      </table>
  </div>
</template>

<script>
import Titulo from '../_share/Titulo'
export default {
    components:{
        Titulo
    },
    data() {
        return {
            aluno:{},
            id: this.$route.params.id
        }
    },
    created() {
        this.$http
        .get("http://localhost:3000/alunos/" + this.id)
        .then(res => res.json())
        .then(aluno => (this.aluno = aluno));
    },
    metgods:{}
};
</script>

<style scoped>
</style>