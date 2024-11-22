import { useState } from 'react';
import { useRouter } from 'next/router';
import { useContext } from 'react';
import { FuncionarioContext } from '../../../contexts/FuncionarioContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import styles from './styles.module.scss';
import { Header } from '../../../components/Header';

const CreateFuncionario = () => {
  const { addFuncionario } = useContext(FuncionarioContext)!;
  const router = useRouter();

  const [codigo, setCodigo] = useState<number | ''>(''); // Campo para o código
  const [nome, setNome] = useState('');
  const [numeroDeRegistro, setNumeroDeRegistro] = useState('');
  const [loading, setLoading] = useState(false);

  const handleCreateFuncionario = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      if (codigo === '') {
        throw new Error('O código é obrigatório.');
      }

      await addFuncionario({
        codigo,
        nome,
        numeroDeRegistro: parseInt(numeroDeRegistro),
      });

      router.push('/funcionarios');
    } catch (error) {
      console.error('Erro ao criar funcionário:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.createFuncionarioContainer}>
          <h1>Criar Novo Funcionário</h1>
          <form onSubmit={handleCreateFuncionario} className={styles.form}>
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
              <label htmlFor="nome">Nome</label>
              <input
                id="nome"
                type="text"
                value={nome}
                onChange={(e) => setNome(e.target.value)}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="numeroDeRegistro">Número de Registro</label>
              <input
                id="numeroDeRegistro"
                type="number"
                value={numeroDeRegistro}
                onChange={(e) => setNumeroDeRegistro(e.target.value)}
                required
              />
            </div>

            <Button type="submit" loading={loading}>
              Criar Funcionário
            </Button>
          </form>
        </div>
      </>
    </MainLayout>
  );
};

export default CreateFuncionario;
