import { useContext, useState, useEffect } from 'react';
import { useRouter } from 'next/router';
import { CidadeContext } from '../../contexts/CidadeContext';
import { EstadoContext } from '../../contexts/EstadoContext';
import MainLayout from '../../components/MainLayout';
import DataTable from '../../components/DataTable';
import FilterAndActions from '../../components/FilterAndActions';
import styles from './styles.module.scss';
import { Header } from '../../components/Header';

const CidadeList = () => {
  const { cidades, deleteCidade } = useContext(CidadeContext)!;
  const { estados, fetchEstados } = useContext(EstadoContext)!;
  const router = useRouter();
  const [searchTerm, setSearchTerm] = useState('');

  useEffect(() => {
    fetchEstados(); // Certifica que os estados estão carregados
  }, [fetchEstados]);

  const filterCidades = () => {
    const filtered = searchTerm
      ? cidades.filter((cidade) =>
          cidade.nome.toLowerCase().includes(searchTerm.toLowerCase())
        )
      : cidades;

    // Ordena por ordem alfabética do nome da cidade
    return filtered.sort((a, b) => a.nome.localeCompare(b.nome));
  };

  const getEstadoNome = (codigoDoEstado: number) => {
    const estado = estados.find((estado) => estado.codigo === codigoDoEstado);
    return estado ? estado.nome : 'Estado Não Encontrado';
  };

  const columns = [
    { key: 'nome', label: 'Nome' },
    {
      key: 'codigoDoEstado',
      label: 'Estado',
      render: (cidade: any) => getEstadoNome(cidade.codigoDoEstado), // Renderiza o nome do estado
    },
    { key: 'precoPadrao', label: 'Preço Padrão' },
  ];

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.cidadeListContainer}>
          <h1 className={styles.title}>Listagem de Cidades</h1>

          <FilterAndActions
            searchTerm={searchTerm}
            setSearchTerm={setSearchTerm}
            buttonLabel="Adicionar Nova Cidade"
            onButtonClick={() => router.push('/cidades/create')}
          />

          <DataTable
            data={filterCidades()}
            columns={columns}
            onRowClick={(cidade) => router.push(`/cidades/${cidade.codigo}`)}
            actionLabel="Deletar"
            onActionClick={(cidade) => deleteCidade(cidade.codigo)}
          />
        </div>
      </>
    </MainLayout>
  );
};

export default CidadeList;
