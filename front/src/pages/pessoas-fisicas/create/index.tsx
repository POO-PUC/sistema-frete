import { useState } from 'react';
import { useRouter } from 'next/router';
import { useContext } from 'react';
import { PessoaFisicaContext } from '../../../contexts/PessoaFisicaContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import styles from './styles.module.scss';
import { Header } from '../../../components/Header';

const CreatePessoaFisica = () => {
  const { addPessoaFisica } = useContext(PessoaFisicaContext)!;
  const router = useRouter();

  const [codigo, setCodigo] = useState<number | ''>(''); // Código único
  const [nome, setNome] = useState('');
  const [cpf, setCpf] = useState('');
  const [codigoDoRepresentante, setCodigoDoRepresentante] = useState<number | ''>('');
  const [loading, setLoading] = useState(false);

  const handleCreatePessoaFisica = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      if (codigo === '') {
        throw new Error('O código é obrigatório.');
      }

      await addPessoaFisica({
        codigo,
        nome,
        cpf,
        codigoDoRepresentante: codigoDoRepresentante || 0, // Representante opcional
      });

      router.push('/pessoas-fisicas');
    } catch (error) {
      console.error('Erro ao criar pessoa física:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <Header />
      <div className={styles.createPessoaFisicaContainer}>
        <h1>Criar Nova Pessoa Física</h1>
        <form onSubmit={handleCreatePessoaFisica} className={styles.form}>
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
            Criar Pessoa Física
          </Button>
        </form>
      </div>
    </MainLayout>
  );
};

export default CreatePessoaFisica;
