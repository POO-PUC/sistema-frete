import { useState } from 'react';
import { useRouter } from 'next/router';
import { useContext } from 'react';
import { EstadoContext } from '../../../contexts/EstadoContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import styles from './styles.module.scss';
import { Header } from '../../../components/Header';
import { toast } from 'react-toastify';

const CreateEstado = () => {
  const { addEstado } = useContext(EstadoContext)!;
  const router = useRouter();

  const [codigo, setCodigo] = useState<number | ''>(''); // Campo para o código
  const [nome, setNome] = useState('');
  const [uf, setUf] = useState('');
  const [icmsLocal, setIcmsLocal] = useState('');
  const [icmsExterno, setIcmsExterno] = useState('');
  const [loading, setLoading] = useState(false);

  const handleCreateEstado = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      if (codigo === '') {
        throw new Error('O código é obrigatório.');
      }

      await addEstado({
        codigo, // Inclui o código no payload
        nome,
        uf,
        icmsLocal: parseFloat(icmsLocal),
        icmsExterno: parseFloat(icmsExterno),
      });
      toast.success('Estado criado com sucesso!');
      router.push('/estados');
    } catch (error) {
      console.error('Erro ao criar estado:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.createEstadoContainer}>
          <h1>Criar Novo Estado</h1>
          <form onSubmit={handleCreateEstado} className={styles.form}>
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
              <label htmlFor="nome">Nome do Estado</label>
              <input
                id="nome"
                type="text"
                value={nome}
                onChange={(e) => setNome(e.target.value)}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="uf">UF</label>
              <input
                id="uf"
                type="text"
                value={uf}
                onChange={(e) => setUf(e.target.value)}
                maxLength={2}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="icmsLocal">ICMS Local (%)</label>
              <input
                id="icmsLocal"
                type="number"
                step="0.01"
                value={icmsLocal}
                onChange={(e) => setIcmsLocal(e.target.value)}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="icmsExterno">ICMS Externo (%)</label>
              <input
                id="icmsExterno"
                type="number"
                step="0.01"
                value={icmsExterno}
                onChange={(e) => setIcmsExterno(e.target.value)}
                required
              />
            </div>

            <Button type="submit" loading={loading}>
              Criar Estado
            </Button>
          </form>
        </div>
      </>
    </MainLayout>
  );
};

export default CreateEstado;
