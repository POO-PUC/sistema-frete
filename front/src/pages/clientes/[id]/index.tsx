import { useRouter } from 'next/router';
import { useContext, useEffect, useState } from 'react';
import { ClienteContext } from '../../../contexts/ClienteContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import styles from './styles.module.scss';
import { Header } from '../../../components/Header';

const EditCliente = () => {
  const { clientes, updateCliente } = useContext(ClienteContext)!;
  const router = useRouter();
  const { id } = router.query;

  const [endereco, setEndereco] = useState('');
  const [telefone, setTelefone] = useState('');
  const [dataDeInscricao, setDataDeInscricao] = useState('');
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const cliente = clientes.find((c) => c.codigo === Number(id));
    if (cliente) {
      setEndereco(cliente.endereco);
      setTelefone(cliente.telefone);

      // Converte a data para o formato esperado pelo campo de entrada
      const formattedDate = cliente.dataDeInscricao
        ? new Date(cliente.dataDeInscricao).toISOString().split('T')[0]
        : '';
      setDataDeInscricao(formattedDate);
    }
  }, [id, clientes]);

  const handleUpdateCliente = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      await updateCliente(Number(id), {
        endereco,
        telefone,
        dataDeInscricao,
      });

      router.push('/clientes');
    } catch (error) {
      console.error('Erro ao atualizar cliente:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <Header />
      <div className={styles.editClienteContainer}>
        <h1>Editar Cliente</h1>
        <form onSubmit={handleUpdateCliente} className={styles.form}>
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
            Atualizar Cliente
          </Button>
        </form>
      </div>
    </MainLayout>
  );
};

export default EditCliente;
