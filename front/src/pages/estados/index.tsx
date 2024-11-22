import { useContext, useState } from 'react';
import { useRouter } from 'next/router';
import { EstadoContext } from '../../contexts/EstadoContext';
import MainLayout from '../../components/MainLayout';
import DataTable from '../../components/DataTable';
import FilterAndActions from '../../components/FilterAndActions';
import styles from './styles.module.scss';
import { Header } from '../../components/Header';

const EstadoList = () => {
  const { estados, deleteEstado } = useContext(EstadoContext)!;
  const router = useRouter();
  const [searchTerm, setSearchTerm] = useState('');

  const filterEstados = () => {
    const filtered = searchTerm
      ? estados.filter((estado) =>
          estado.nome.toLowerCase().includes(searchTerm.toLowerCase())
        )
      : estados;

    // Ordena por ordem alfabética do nome do estado
    return filtered.sort((a, b) => a.nome.localeCompare(b.nome));
  };

  const columns = [
    { key: 'nome', label: 'Nome' },
    { key: 'uf', label: 'UF' },
    { key: 'icmsLocal', label: 'ICMS Local (%)' },
    { key: 'icmsExterno', label: 'ICMS Externo (%)' },
  ];

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.estadoListContainer}>
          <h1 className={styles.title}>Listagem de Estados</h1>

          <FilterAndActions
            searchTerm={searchTerm}
            setSearchTerm={setSearchTerm}
            buttonLabel="Adicionar Novo Estado"
            onButtonClick={() => router.push('/estados/create')}
          />

          <DataTable
            data={filterEstados()}
            columns={columns}
            onRowClick={(estado) => router.push(`/estados/${estado.codigo}`)}
            actionLabel="Deletar"
            onActionClick={(estado) => deleteEstado(estado.codigo)}
          />
        </div>
      </>
    </MainLayout>
  );
};

export default EstadoList;
