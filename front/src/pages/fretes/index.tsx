import { useContext, useState } from 'react';
import { useRouter } from 'next/router';
import { FreteContext } from '../../contexts/FreteContext';
import MainLayout from '../../components/MainLayout';
import DataTable from '../../components/DataTable';
import FilterAndActions from '../../components/FilterAndActions';
import styles from './styles.module.scss';
import { Header } from '../../components/Header';

const FreteList = () => {
  const { fretes, deleteFrete } = useContext(FreteContext)!;
  const router = useRouter();
  const [searchTerm, setSearchTerm] = useState('');

  const filterFretes = () => {
    if (!searchTerm) return fretes;
    return fretes.filter((frete) =>
      frete.numeroDeConhecimento.toLowerCase().includes(searchTerm.toLowerCase())
    );
  };

  const columns = [
    { key: 'numeroDeConhecimento', label: 'Número de Conhecimento' },
    { key: 'valor', label: 'Valor' },
    { key: 'icms', label: 'ICMS' },
    { key: 'pedagio', label: 'Pedágio' },
    { key: 'dataInicio', label: 'Data de Início' },
  ];

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.freteListContainer}>
          <h1 className={styles.title}>Listagem de Fretes</h1>

          <FilterAndActions
            searchTerm={searchTerm}
            setSearchTerm={setSearchTerm}
            buttonLabel="Adicionar Novo Frete"
            onButtonClick={() => router.push('/fretes/create')}
          />

          <DataTable
            data={filterFretes()}
            columns={columns}
            onRowClick={(frete) => router.push(`/fretes/${frete.codigo}`)}
            actionLabel="Deletar"
            onActionClick={(frete) => deleteFrete(frete.codigo)}
          />
        </div>
      </>
    </MainLayout>
  );
};

export default FreteList;
