import { useContext, useState } from 'react';
import { useRouter } from 'next/router';
import { PessoaFisicaContext } from '../../contexts/PessoaFisicaContext';
import MainLayout from '../../components/MainLayout';
import DataTable from '../../components/DataTable';
import FilterAndActions from '../../components/FilterAndActions';
import styles from './styles.module.scss';
import { Header } from '../../components/Header';

const PessoaFisicaList = () => {
  const { pessoasFisicas, deletePessoaFisica } = useContext(PessoaFisicaContext)!;
  const router = useRouter();
  const [searchTerm, setSearchTerm] = useState('');

  const filterPessoasFisicas = () => {
    if (!searchTerm) return pessoasFisicas;
    return pessoasFisicas.filter((pf) =>
      pf.nome.toLowerCase().includes(searchTerm.toLowerCase())
    );
  };

  const columns = [
    { key: 'codigo', label: 'Código' },
    { key: 'nome', label: 'Nome' },
    { key: 'cpf', label: 'CPF' },
  ];

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.pessoaFisicaListContainer}>
          <h1 className={styles.title}>Listagem de Pessoas Físicas</h1>

          <FilterAndActions
            searchTerm={searchTerm}
            setSearchTerm={setSearchTerm}
            buttonLabel="Adicionar Nova Pessoa Física"
            onButtonClick={() => router.push('/pessoas-fisicas/create')}
          />

          <DataTable
            data={filterPessoasFisicas()}
            columns={columns}
            onRowClick={(pf) => router.push(`/pessoas-fisicas/${pf.codigo}`)}
            actionLabel="Deletar"
            onActionClick={(pf) => deletePessoaFisica(pf.codigo)}
          />
        </div>
      </>
    </MainLayout>
  );
};

export default PessoaFisicaList;
