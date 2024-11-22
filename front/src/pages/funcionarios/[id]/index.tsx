import { useRouter } from 'next/router';
import { useContext, useEffect, useState } from 'react';
import { FuncionarioContext } from '../../../contexts/FuncionarioContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import styles from './styles.module.scss';
import { Header } from '../../../components/Header';

const EditFuncionario = () => {
  const { funcionarios, updateFuncionario } = useContext(FuncionarioContext)!;
  const router = useRouter();
  const { id } = router.query;

  const [nome, setNome] = useState('');
  const [numeroDeRegistro, setNumeroDeRegistro] = useState('');
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const funcionario = funcionarios.find((f) => f.codigo === Number(id));
    if (funcionario) {
      setNome(funcionario.nome);
      setNumeroDeRegistro(String(funcionario.numeroDeRegistro));
    }
  }, [id, funcionarios]);

  const handleUpdateFuncionario = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      await updateFuncionario(Number(id), {
        nome,
        numeroDeRegistro: parseInt(numeroDeRegistro),
      });

      router.push('/funcionarios');
    } catch (error) {
      console.error('Erro ao atualizar funcionário:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.editFuncionarioContainer}>
          <h1>Editar Funcionário</h1>
          <form onSubmit={handleUpdateFuncionario} className={styles.form}>
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
              Atualizar Funcionário
            </Button>
          </form>
        </div>
      </>
    </MainLayout>
  );
};

export default EditFuncionario;
