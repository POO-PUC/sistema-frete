import { useContext, useState } from 'react';
import { useRouter } from 'next/router';
import { PessoaJuridicaContext } from '../../contexts/PessoaJuridicaContext';
import MainLayout from '../../components/MainLayout';
import DataTable from '../../components/DataTable';
import FilterAndActions from '../../components/FilterAndActions';
import styles from './styles.module.scss';
import { Header } from '../../components/Header';

const PessoaJuridicaList = () => {
  const { pessoasJuridicas, deletePessoaJuridica } = useContext(PessoaJuridicaContext)!;
  const router = useRouter();
  const [searchTerm, setSearchTerm] = useState('');

  const filterPessoasJuridicas = () => {
    if (!searchTerm) return pessoasJuridicas;
    return pessoasJuridicas.filter((pj) =>
      pj.razaoSocial.toLowerCase().includes(searchTerm.toLowerCase())
    );
  };

  const columns = [
    { key: 'razaoSocial', label: 'Razão Social' },
    { key: 'cnpj', label: 'CNPJ' },
  ];

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.pessoaJuridicaListContainer}>
          <h1 className={styles.title}>Listagem de Pessoas Jurídicas</h1>

          <FilterAndActions
            searchTerm={searchTerm}
            setSearchTerm={setSearchTerm}
            buttonLabel="Adicionar Nova Pessoa Jurídica"
            onButtonClick={() => router.push('/pessoas-juridicas/create')}
          />

          <DataTable
            data={filterPessoasJuridicas()}
            columns={columns}
            onRowClick={(pj) => router.push(`/pessoas-juridicas/${pj.codigo}`)}
            actionLabel="Deletar"
            onActionClick={(pj) => deletePessoaJuridica(pj.codigo)}
          />
        </div>
      </>
    </MainLayout>
  );
};

export default PessoaJuridicaList;
