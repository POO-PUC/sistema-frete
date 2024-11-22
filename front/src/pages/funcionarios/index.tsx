import { useContext, useState } from 'react';
import { useRouter } from 'next/router';
import { FuncionarioContext } from '../../contexts/FuncionarioContext';
import MainLayout from '../../components/MainLayout';
import DataTable from '../../components/DataTable';
import FilterAndActions from '../../components/FilterAndActions';
import styles from './styles.module.scss';
import { Header } from '../../components/Header';

const FuncionarioList = () => {
  const { funcionarios, deleteFuncionario } = useContext(FuncionarioContext)!;
  const router = useRouter();
  const [searchTerm, setSearchTerm] = useState('');

  const filterFuncionarios = () => {
    if (!searchTerm) return funcionarios;
    return funcionarios.filter((funcionario) =>
      funcionario.nome.toLowerCase().includes(searchTerm.toLowerCase())
    );
  };

  const columns = [
    { key: 'codigo', label: 'Código' },
    { key: 'nome', label: 'Nome' },
    { key: 'numeroDeRegistro', label: 'Número de Registro' },
  ];

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.funcionarioListContainer}>
          <h1 className={styles.title}>Listagem de Funcionários</h1>

          <FilterAndActions
            searchTerm={searchTerm}
            setSearchTerm={setSearchTerm}
            buttonLabel="Adicionar Novo Funcionário"
            onButtonClick={() => router.push('/funcionarios/create')}
          />

          <DataTable
            data={filterFuncionarios()}
            columns={columns}
            onRowClick={(funcionario) => router.push(`/funcionarios/${funcionario.codigo}`)}
            actionLabel="Deletar"
            onActionClick={(funcionario) => deleteFuncionario(funcionario.codigo)}
          />
        </div>
      </>
    </MainLayout>
  );
};

export default FuncionarioList;
