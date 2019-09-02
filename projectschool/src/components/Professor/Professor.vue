<template>
  <div>
    <titulo texto="Professores" />
    <table>
      <thead>
        <th>Código.</th>
        <th>Nome</th>
        <th>Alunos</th>
      </thead>
      <tbody v-if="Professores.length">
        <tr v-for="(professor, index) in Professores" :key="index">
          <td>{{ professor.id }}</td>
          <td>{{ professor.nome }} {{ professor.sobrenome}}</td>
          <td>3</td>
        </tr>
      </tbody>
      <tfoot v-else>Nenhum professor encontrado</tfoot>
    </table>
  </div>
</template>

<script>
import Titulo from "../_share/Titulo";

export default {
  components: {
    Titulo
  },
  data() {
    return {
      Professores: [
        { id: 1, nome: "Cristiano", sobrenome: "Lautert" },
        { id: 2, nome: "Paula", sobrenome: "Franco" },
        { id: 3, nome: "Luna", sobrenome: "Moraes" }
      ]
    };
  }
};
</script>

<style scoped>
</style>