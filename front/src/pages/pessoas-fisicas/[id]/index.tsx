import { useRouter } from 'next/router';
import { useContext, useEffect, useState } from 'react';
import { PessoaFisicaContext } from '../../../contexts/PessoaFisicaContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import styles from './styles.module.scss';
import { Header } from '../../../components/Header';

const EditPessoaFisica = () => {
  const { pessoasFisicas, updatePessoaFisica } = useContext(PessoaFisicaContext)!;
  const router = useRouter();
  const { id } = router.query;

  const [nome, setNome] = useState('');
  const [cpf, setCpf] = useState('');
  const [codigoDoRepresentante, setCodigoDoRepresentante] = useState<number | ''>('');
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const pessoaFisica = pessoasFisicas.find((pf) => pf.codigo === Number(id));
    if (pessoaFisica) {
      setNome(pessoaFisica.nome);
      setCpf(pessoaFisica.cpf);
      setCodigoDoRepresentante(pessoaFisica.codigoDoRepresentante || '');
    }
  }, [id, pessoasFisicas]);

  const handleUpdatePessoaFisica = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      await updatePessoaFisica(Number(id), {
        nome,
        cpf,
        codigoDoRepresentante: codigoDoRepresentante || 0, // Representante opcional
      });

      router.push('/pessoas-fisicas');
    } catch (error) {
      console.error('Erro ao atualizar pessoa física:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <Header />
      <div className={styles.editPessoaFisicaContainer}>
        <h1>Editar Pessoa Física</h1>
        <form onSubmit={handleUpdatePessoaFisica} className={styles.form}>
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
            <label htmlFor="cpf">CPF</label>
            <input
              id="cpf"
              type="text"
              value={cpf}
              onChange={(e) => setCpf(e.target.value)}
              required
            />
          </div>

          <div className={styles.formGroup}>
            <label htmlFor="codigoDoRepresentante">Código do Representante</label>
            <input
              id="codigoDoRepresentante"
              type="number"
              value={codigoDoRepresentante}
              onChange={(e) => setCodigoDoRepresentante(Number(e.target.value))}
            />
          </div>

          <Button type="submit" loading={loading}>
            Atualizar Pessoa Física
          </Button>
        </form>
      </div>
    </MainLayout>
  );
};

export default EditPessoaFisica;
