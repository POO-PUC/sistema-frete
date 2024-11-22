import { useRouter } from 'next/router';
import { useContext, useEffect, useState } from 'react';
import { CidadeContext } from '../../../contexts/CidadeContext';
import { EstadoContext } from '../../../contexts/EstadoContext';
import MainLayout from '../../../components/MainLayout';
import { Button } from '../../../components/ui/Button';
import { Select } from '../../../components/ui/Select';
import styles from './styles.module.scss';
import { Header } from '../../../components/Header';
import { toast } from 'react-toastify';

const EditCidade = () => {
  const { cidades, updateCidade } = useContext(CidadeContext)!;
  const { estados } = useContext(EstadoContext)!;
  const router = useRouter();
  const { id } = router.query;

  const [nome, setNome] = useState('');
  const [codigoDoEstado, setCodigoDoEstado] = useState<number | ''>('');
  const [precoPadrao, setPrecoPadrao] = useState('');
  const [loading, setLoading] = useState(false);

  useEffect(() => {
    const cidade = cidades.find((c) => c.codigo === Number(id));
    if (cidade) {
      setNome(cidade.nome);
      setCodigoDoEstado(cidade.codigoDoEstado);
      setPrecoPadrao(String(cidade.precoPadrao));
    }
  }, [id, cidades]);

  const handleUpdateCidade = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);

    try {
      await updateCidade(Number(id), {
        nome,
        codigoDoEstado: Number(codigoDoEstado), // Certifica-se de que seja um número
        precoPadrao: parseFloat(precoPadrao),
      });
      toast.success('Cidade atualizada com sucesso!');
      router.push('/cidades');
    } catch (error) {
      console.error('Erro ao atualizar cidade:', error);
      toast.error('Erro ao atualizar cidade.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <MainLayout>
      <>
        <Header />
        <div className={styles.editCidadeContainer}>
          <h1>Editar Cidade</h1>
          <form onSubmit={handleUpdateCidade} className={styles.form}>
            <div className={styles.formGroup}>
              <label htmlFor="nome">Nome da Cidade</label>
              <input
                id="nome"
                type="text"
                value={nome}
                onChange={(e) => setNome(e.target.value)}
                required
              />
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="codigoDoEstado">Estado</label>
              <Select
                id="codigoDoEstado"
                value={codigoDoEstado} // Vincula ao estado
                onChange={(e) => setCodigoDoEstado(Number(e.target.value))} // Atualiza ao mudar
                required
              >
                <option value="">Selecione um estado</option>
                {estados.map((estado) => (
                  <option key={estado.codigo} value={estado.codigo}>
                    {estado.nome}
                  </option>
                ))}
              </Select>
            </div>

            <div className={styles.formGroup}>
              <label htmlFor="precoPadrao">Preço Padrão</label>
              <input
                id="precoPadrao"
                type="number"
                step="0.01"
                value={precoPadrao}
                onChange={(e) => setPrecoPadrao(e.target.value)}
                required
              />
            </div>

            <Button type="submit" loading={loading}>
              Atualizar Cidade
            </Button>
          </form>
        </div>
      </>
    </MainLayout>
  );
};

export default EditCidade;
