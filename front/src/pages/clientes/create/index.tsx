import { useState } from 'react';
import { useRouter } from 'next/router';
import { useContext } from 'react';
import { ClienteContext } from '../../../contexts/ClienteContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import styles from './styles.module.scss';
import { Header } from '../../../components/Header';

const CreateCliente = () => {
  const { addCliente } = useContext(ClienteContext)!;
  const router = useRouter();

  const [codigo, setCodigo] = useState<number | ''>(''); // Campo para o código
  const [endereco, setEndereco] = useState('');
  const [telefone, setTelefone] = useState('');
  const [dataDeInscricao, setDataDeInscricao] = useState('');
  const [loading, setLoading] = useState(false);

  const handleCreateCliente = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      if (codigo === '') {
        throw new Error('O código é obrigatório.');
      }

      await addCliente({
        codigo,
        endereco,
        telefone,
        dataDeInscricao,
      });

      router.push('/clientes');
    } catch (error) {
      console.error('Erro ao criar cliente:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.createClienteContainer}>
          <h1>Criar Novo Cliente</h1>
          <form onSubmit={handleCreateCliente} className={styles.form}>
            <div className={styles.formGroup}>
              <label htmlFor="codigo">Código</label>
              <input
                id="codigo"
                type="number"
                value={codigo}
                onChange={(e) => setCodigo(Number(e.target.value))}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="endereco">Endereço</label>
              <input
                id="endereco"
                type="text"
                value={endereco}
                onChange={(e) => setEndereco(e.target.value)}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="telefone">Telefone</label>
              <input
                id="telefone"
                type="text"
                value={telefone}
                onChange={(e) => setTelefone(e.target.value)}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="dataDeInscricao">Data de Inscrição</label>
              <input
                id="dataDeInscricao"
                type="date"
                value={dataDeInscricao}
                onChange={(e) => setDataDeInscricao(e.target.value)}
                required
              />
            </div>

            <Button type="submit" loading={loading}>
              Criar Cliente
            </Button>
          </form>
        </div>
      </>
    </MainLayout>
  );
};

export default CreateCliente;
