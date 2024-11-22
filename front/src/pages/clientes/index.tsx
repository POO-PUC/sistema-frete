import { useContext, useState } from 'react';
import { useRouter } from 'next/router';
import { ClienteContext } from '../../contexts/ClienteContext';
import MainLayout from '../../components/MainLayout';
import DataTable from '../../components/DataTable';
import FilterAndActions from '../../components/FilterAndActions';
import styles from './styles.module.scss';
import { Header } from '../../components/Header';

// Função para formatar a data
const formatDate = (dateString: string) => {
  if (!dateString) return '-'; // Retorna um traço se a data for inválida
  const date = new Date(dateString);
  return date.toLocaleDateString('pt-BR', {
    day: '2-digit',
    month: '2-digit',
    year: 'numeric',
  });
};

const ClienteList = () => {
  const { clientes, deleteCliente } = useContext(ClienteContext)!;
  const router = useRouter();
  const [searchTerm, setSearchTerm] = useState('');

  const filterClientes = () => {
    if (!searchTerm) return clientes;
    return clientes.filter((cliente) =>
      cliente.endereco.toLowerCase().includes(searchTerm.toLowerCase())
    );
  };

  const columns = [
    { key: 'codigo', label: 'Código' },
    { key: 'endereco', label: 'Endereço' },
    { key: 'telefone', label: 'Telefone' },
    {
      key: 'dataDeInscricao',
      label: 'Data de Inscrição',
      render: (row: any) => formatDate(row.dataDeInscricao), // Formata a data na coluna
    },
  ];

  return (
    <MainLayout>
      <Header />
      <div className={styles.clienteListContainer}>
        <h1 className={styles.title}>Listagem de Clientes</h1>

        <FilterAndActions
          searchTerm={searchTerm}
          setSearchTerm={setSearchTerm}
          buttonLabel="Adicionar Novo Cliente"
          onButtonClick={() => router.push('/clientes/create')}
        />

        <DataTable
          data={filterClientes()}
          columns={columns}
          onRowClick={(cliente) => router.push(`/clientes/${cliente.codigo}`)}
          actionLabel="Deletar"
          onActionClick={(cliente) => deleteCliente(cliente.codigo)}
        />
      </div>
    </MainLayout>
  );
};

export default ClienteList;
