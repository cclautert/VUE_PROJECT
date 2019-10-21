<template>
  <div>
      <titulo  :texto="`Aluno: ${aluno.nome}`"/>
      <table>
          <tbody>
              <tr>
                  <td class="colPequeno"> Matrícula:</td>
                  <td>
                      <label>{{aluno.id}}</label>                      
                  </td>
              </tr>
              <tr>
                  <td>Nome:</td>
                  <td>
                      <label>{{aluno.nome}}</label>
                      <input v-model="aluno.nome" type="text"/>
                  </td>
              </tr>
              <tr>
                  <td>SobreNome:</td>
                  <td>
                      <label>{{aluno.sobrenome}}</label>
                      <input v-model="aluno.sobrenome" type="text"/>
                  </td>
              </tr>
              <tr>
                  <td>Data Nescimento:</td>
                  <td>
                      <label>{{aluno.dataNasc}}</label>
                      <input v-model="aluno.dataNasc" type="text"/>
                  </td>
              </tr>
              <tr>
                  <td>Professor:</td>
                  <td>
                      <label>{{aluno.professor.nome}}</label>
                      <select v-model="aluno.professor">
                          <option></option> v-for="(professor, index) in professores" :key="index"
                      </select>                      
                  </td>
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
            professores:{},
            aluno:{},
            id: this.$route.params.id
        }
    },
    created() {
        this.$http
        .get("http://localhost:3000/alunos/" + this.id)
        .then(res => res.json())
        .then(aluno => (this.aluno = aluno));
        
      this.$http
        .get("http://localhost:3000/professores")
        .then(res => res.json())
        .then(professor => this.professores = professor);
    },
    metgods:{}
};
</script>

<style scoped>
</style>